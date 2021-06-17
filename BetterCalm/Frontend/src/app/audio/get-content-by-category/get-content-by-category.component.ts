import {Component, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-get-content-by-category',
  templateUrl: './get-content-by-category.component.html',
  styleUrls: ['./get-content-by-category.component.css']
})
export class GetContentByCategoryComponent implements OnInit {

  contents: Array<Content> | undefined;
  filter = '';
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
    this.contentService.delete(id).subscribe(
    );
    this.contents = this.contents?.filter(p => p.id !== id);
  }

  filtrar(): void {
    this.contentService.getByCategoryName(this.filter).subscribe(
      (data: Array<Content>) => {
        this.getByCategoryName(data);
      },
    );
  }

  getByCategoryName(data: Array<Content>): void{
    this.contents = data;
  }
}
