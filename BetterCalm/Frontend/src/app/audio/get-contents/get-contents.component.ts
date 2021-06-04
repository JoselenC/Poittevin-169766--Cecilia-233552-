import {Component, OnInit} from '@angular/core';
import {ContentService} from '../../services/content/content.service';
import {Content} from '../../models/Content';

@Component({
  selector: 'app-get-contents',
  templateUrl: './get-contents.component.html',
  styleUrls: ['./get-contents.component.css']
})
export class GetContentsComponent implements OnInit {

  public contents: Content[] = [];

  constructor(private contentService: ContentService) {
  }

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


}
