import {Component, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ActivatedRoute} from '@angular/router';
import {ContentService} from '../../services/content/content.service';
import {Observable} from 'rxjs';
import {DomSanitizer, SafeResourceUrl} from '@angular/platform-browser';

@Component({
  selector: 'app-content-detail',
  templateUrl: './content-detail.component.html',
  styleUrls: ['./content-detail.component.css']
})
export class ContentDetailComponent implements OnInit {
  content: Content | undefined;
  public url = 'https://cdn3.iconfinder.com/data/icons/audio-visual-acquicons/512/Eighth-Note-Double.png';
  urlVideo: string | undefined;

  constructor(
    private sanitizer: DomSanitizer,
    private route: ActivatedRoute,
    private contentService: ContentService
  ) {
  }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const contentId = Number(routeParams.get('contentId'));

    this.contentService.getById(contentId).subscribe(
      content => {
        this.content = new Content(content.id, content.name, content.creatorName,
          content.urlArchive, content.urlImage, content.duration, content.categories, content.type);
      }
    );
  }

  getEmbebedUrl(): SafeResourceUrl {
    if (this.content!.urlArchive!.includes('youtube')) {
      return this.sanitizer.bypassSecurityTrustResourceUrl('https://www.youtube.com/embed/' + this.content!.urlArchive!.split('=')[1]);
    } else if (this.content!.urlArchive!.includes('vimeo')) {
      return this.sanitizer.bypassSecurityTrustResourceUrl(this.content!.urlArchive!);
    }
    return this.sanitizer.bypassSecurityTrustResourceUrl('');
  }

}
