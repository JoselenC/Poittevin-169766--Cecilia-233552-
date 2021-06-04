import { Component, OnInit } from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';

@Component({
  selector: 'app-delete-content',
  templateUrl: './delete-content.component.html',
  styleUrls: ['./delete-content.component.css']
})
export class DeleteContentComponent implements OnInit {

  public contents: Content[] = [];

  constructor(private contentService: ContentService) { }

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

  DeleteContent(content: Content): void {
    this.contentService.delete(content.id).subscribe(
      (error: any) => alert(error)
    );
  }
}
