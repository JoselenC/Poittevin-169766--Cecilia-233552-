import {Component, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {Router} from '@angular/router';
import {ContentService} from '../../services/content/content.service';
import {Playlist} from '../../models/Playlist';
import {Category} from '../../models/Category';


@Component({
  selector: 'app-get-contents',
  templateUrl: './get-contents.component.html',
  styleUrls: ['./get-contents.component.css']
})
export class GetContentsComponent implements OnInit {

  public contents: Content[] = [];
  public url = 'https://cdn3.iconfinder.com/data/icons/audio-visual-acquicons/512/Eighth-Note-Double.png';
  constructor(
    private contentService: ContentService,
    private router: Router
  ) {  }

  ngOnInit(): void {
    this.contentService.getAll()
      .subscribe(
        ((data: Array<Content>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }

  private result(data: Array<Content>): void {
    this.contents = data;
  }

  navigateTo(contentId?: number): void {
    this.router.navigate(['contents', contentId]);
  }

  delete(id?: number): void {
    this.contentService.delete(id).subscribe(
      (error: any) => alert(error)
    );
    this.contents = this.contents.filter(p => p.id !== id);
  }

  navigateToAddEdit(content ?: Content): void {
    if (content === undefined) {
      content = new Content(
        0,
        '',
        '',
        '',
        '',
        '',
        new Array<Category>(),
        ''
      ); }
    this.router.navigate(['add-content'], {state: {content}});
  }
}
