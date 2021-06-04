import {Category} from './Category';

export class Content {
  id: number;
  name: string;
  authorName: string;
  urlAudio: string;
  urlImage: string;
  categories: Array<Category>;
  duration: string;

  constructor(id: number, name: string, authorName: string, urlAudio: string, urlImage: string, duration: string){
    this.id = id;
    this.categories = new Array<Category>();
    this.name = name;
    this.authorName = authorName;
    this.urlAudio = urlAudio;
    this.urlImage = urlImage;
    this.duration = duration;
  }

}
