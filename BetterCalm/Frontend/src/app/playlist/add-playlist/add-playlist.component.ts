import { Component, OnInit } from '@angular/core';
import {Playlist} from '../../models/Playlist';
import {PlaylistService} from '../../services/playlist/playlist.service';
import {Router} from '@angular/router';
import {Category} from '../../models/Category';
import {CategoryService} from '../../services/category/category.service';
import {FormBuilder, FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-add-playlist',
  templateUrl: './add-playlist.component.html',
  styleUrls: ['./add-playlist.component.css']
})
export class AddPlaylistComponent implements OnInit {
  constructor(
    private servicePlaylist: PlaylistService,
    private serviceCategory: CategoryService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {}

  id = 0;
  name = '';
  authorName = '';
  urlPlaylist = '';
  urlImage = '';
  duration = '';
  data = Playlist;
  categories: Array<string> = [
    'Musica'
  ];
  cat = new FormControl();
  catGroup ?: FormGroup;

  ngOnInit(): void {
    this.initFormCategories();
  }

  initFormCategories(): void {
    this.catGroup = this.formBuilder.group({
      categoriesToString: this.cat
    });
  }


  addPlaylist(): void {
    const playlist = new Playlist (
      this.id,
      this.name,
      this.cat.value.map((x: any) => (new Category(0, x))),
    );
    this.servicePlaylist.newPlaylist(playlist).subscribe(
      (data: Playlist) => this.result(data),
      (error: any) => {
        console.log(error);
        alert(error);
      }
    );
  }

  // tslint:disable-next-line:typedef
  private result(data: Playlist) {
    this.router.navigate(['/playlists']);
  }
}


