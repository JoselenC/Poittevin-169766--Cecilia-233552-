﻿import {Category} from './Category';

export class Content {
  id: number;
  name: string;
  creatorName: string;
  urlArchive: string;
  urlImage: string;
  categories: Array<Category>;
  duration: string;
  type: string;

  constructor(id: number, name: string, authorName: string, urlAudio: string,
              urlImage: string, duration: string, categories: Array<Category>, type: string){
    this.id = id;
    this.categories = categories;
    this.name = name;
    this.creatorName = authorName;
    this.urlArchive = urlAudio;
    this.urlImage = urlImage;
    this.duration = duration;
    this.type = type;
  }

}

