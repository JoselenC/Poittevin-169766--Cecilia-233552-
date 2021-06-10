import { Component, OnInit } from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {ActivatedRoute, Router} from '@angular/router';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {ContentService} from '../../services/content/content.service';
import {CategoryService} from '../../services/category/category.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';
import {Content} from '../../models/Content';
import {Category} from '../../models/Category';

@Component({
  selector: 'app-update-playlist',
  templateUrl: './update-playlist.component.html',
  styleUrls: ['./update-playlist.component.css']
})
export class UpdatePlaylistComponent implements OnInit {

  constructor(
  private servicePlaylist: PlaylistService,
  private serviceContent: ContentService,
  private categoryService: CategoryService,
  private router: Router,
  private formBuilder: FormBuilder,
  private route: ActivatedRoute,
  ){ }

  id = 0;
  name = '';
  urlImage = '';
  description = '';
  categories: Category[] | undefined;
  cat = new FormControl();
  catGroup ?: FormGroup;
  contents: Content[]| undefined ;
  cont = new FormControl();
  contGroup ?: FormGroup;
  click?: boolean;
  playlist: Playlist | undefined;


  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const playlistId = Number(routeParams.get('playlistId'));

    this.servicePlaylist.getById(playlistId).subscribe(
      playlist => {
        this.playlist = playlist;
      }
    );
    this.categoryService.getCategories().subscribe(
      ((data: Array<Category>) => this.getCategories(data)),
      ((error: any) => alert(error.message))
    );
    this.serviceContent.getAll().subscribe(
      ((data: Array<Content>) => this.getContents(data)),
      ((error: any) => alert(error.message))
    );
    this.initFormCategories();
    this.initFormContents();
  }

  private getCategories(data: Array<Category>): void {
    this.categories = data;
  }

  getContents(data: Array<Content>): void {
    this.contents = data;
  }

  initFormCategories(): void {
    this.catGroup = this.formBuilder.group({
      categoriesToString: this.cat
    });
  }

  initFormContents(): void {
    this.contGroup = this.formBuilder.group({
      contentsToString: this.cont
    });
  }

 reloadContents(): void{
   this.serviceContent.getAll().subscribe(
     ((data: Array<Content>) => this.getContents(data)),
     ((error: any) => alert(error.message))
   );
   this.initFormContents();
 }

  updatePlaylist(): void{
    const routeParams = this.route.snapshot.paramMap;
    const playlistId = Number(routeParams.get('playlistId'));
    const playlist = new Playlist(
      this.id,
      this.name,
      this.urlImage,
      this.description,
      this.cat.value.map((x: any) => (new Category(0, x))),
      this.cont.value.map((x: any ) => ( new Content(x, x.name, x.creatorName, x.type, x.urlImage, x.duration, x.categories, x.urlArchive)))
    );
    this.servicePlaylist.update(playlistId, playlist).subscribe(
      (data: Playlist) => this.result(data),
      (error: any) => alert(error)
    );
  }

  // tslint:disable-next-line:typedef
  private result(data: Playlist) {
    this.router.navigate(['/playlists']);
  }

}
