import {Component, OnInit} from '@angular/core';
import {Content} from '../../models/Content';
import {ContentService} from '../../services/content/content.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-get-content-by-name',
  templateUrl: './get-content-by-name.component.html',
  styleUrls: ['./get-content-by-name.component.css']
})
export class GetContentByNameComponent implements OnInit {

  contents: Array<Content> | undefined;
  filter = '';

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
    this.contents = this.contents?.filter(p => p.id !== id);
  }

  filtrar(): void {
    this.contentService.getByName(this.filter).subscribe(
      (data: Array<Content>) => {
        this.getByName(data);
      },
      ((error: any) => alert(error.message))
    );
  }

  getByName(data: Array<Content>): void{
    this.contents = data;
  }
}
