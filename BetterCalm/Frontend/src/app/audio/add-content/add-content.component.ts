import { Component, OnInit } from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-add-content',
  templateUrl: './add-content.component.html',
  styleUrls: ['./add-content.component.css']
})
export class AddContentComponent implements OnInit {
  constructor(
    private serviceContent: ContentService,
    private router: Router
  ) {}

  id = 0;
  name = '';
  authorName = '';
  urlContent = '';
  urlImage = '';
  duration = '';
  data = Content;

  ngOnInit(): void {
  }


  addContent(): void {
    const content = new Content (
      this.id,
      this.name,
      this.authorName,
      this.urlContent,
      this.urlImage,
      this.duration
    );
    this.serviceContent.newContent(content).subscribe(
      (data: Content) => this.result(data),
      (error: any) => alert(error)
    );
  }

  // tslint:disable-next-line:typedef
  private result(data: Content) {
    this.router.navigate(['/content']);
  }
}

