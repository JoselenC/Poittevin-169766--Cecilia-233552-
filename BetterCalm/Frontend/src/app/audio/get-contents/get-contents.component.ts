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

  navigateTo(contentId: number): void {
    this.router.navigate(['contents', contentId]);
  }

  delete(id: number): void {
    this.contentService.delete(id).subscribe(
      (error: any) => alert(error)
    );
    this.contents = this.contents.filter(p => p.id !== id);
  }
}
