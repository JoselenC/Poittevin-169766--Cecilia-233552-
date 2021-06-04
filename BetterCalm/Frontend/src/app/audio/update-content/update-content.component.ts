import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {ContentService} from '../../services/content/content.service';
import {Content} from '../../models/Content';

@Component({
  selector: 'app-update-content',
  templateUrl: './update-content.component.html',
  styleUrls: ['./update-content.component.css']
})
export class UpdateContentComponent implements OnInit {

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private contentService: ContentService
  ) { }
public contentId = 0;
  public contents: Content[] = [];


id = 0;
  name = '';
  authorName = '';
  urlContent = '';
  urlImage = '';
  duration = '';
  data = Content;

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.contentId = Number(id);
    this.contentService.getAll()
      .subscribe(
        ((data: Array<Content>) => this.result(data)),
        ((error: any) => alert(error.message))
      );
  }
  private result(data: Array<Content>): void {
    this.contents = data;
  }

  updateContent(id: number): void {
    const content = new Content (
      this.id,
      this.name,
      this.authorName,
      this.urlContent,
      this.urlImage,
      this.duration
    );
    this.contentService.update(id, content).subscribe(
      (data: Content) => this.resultData(data),
      (error: any) => alert(error)
    );
  }

  // tslint:disable-next-line:typedef
  private resultData(data: Content) {
    this.router.navigate(['/content']);
  }
}
