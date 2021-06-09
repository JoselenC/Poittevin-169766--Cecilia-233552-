import {Component, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ActivatedRoute} from '@angular/router';
import {ContentService} from '../../services/content/content.service';

@Component({
  selector: 'app-content-detail',
  templateUrl: './content-detail.component.html',
  styleUrls: ['./content-detail.component.css']
})
export class ContentDetailComponent implements OnInit {
  content: Content | undefined;

  constructor(
    private route: ActivatedRoute,
    private contentService: ContentService
  ) {
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const contentId = Number(routeParams.get('contentId'));

    this.contentService.getById(contentId).subscribe(
      content => {
        this.content = content;
      }
    );
  }

}
