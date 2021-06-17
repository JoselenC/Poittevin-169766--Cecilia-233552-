import {Component, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {Router} from '@angular/router';
import {ContentService} from '../../services/content/content.service';


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
      );
  }

  private result(data: Array<Content>): void {
    this.contents = data;
  }

  navigateTo(contentId?: number): void {
    this.router.navigate(['contents', contentId]);
  }

  delete(id?: number): void {
    this.contentService.delete(id).subscribe();
    this.contents = this.contents.filter(p => p.id !== id);
  }
}
