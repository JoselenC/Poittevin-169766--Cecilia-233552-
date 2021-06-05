import {Category} from './Category';
import {Content} from './Content';

export class Playlist {
  id: number;
  name: string;
  urlImage: string;
  categories: Array<Category>;
  contents: Array<Content>;
  description: string;

  constructor(id: number, name: string , urlImage: string , description: string){
    this.id = id;
    this.categories = new Array<Category>();
    this.contents = new Array<Content>();
    this.name = name;
    this.urlImage = urlImage;
    this.description = description;
  }

}
