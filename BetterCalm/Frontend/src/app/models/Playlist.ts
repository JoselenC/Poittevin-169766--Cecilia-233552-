﻿import {Category} from './Category';
import {Content} from './Content';

export class Playlist {
  id: number;
  name: string;
  urlImage: string;
  categories: Array<Category>;
  audios: Array<Content>;
  description: string;

  constructor(id: number, name: string , urlImage: string , description: string){
    this.id = id;
    this.categories = new Array<Category>();
    this.audios = new Array<Content>();
    this.name = name;
    this.urlImage = urlImage;
    this.description = description
  }

}
