import {Category} from './Category';

export class Content {
  id: number | undefined;
  name: string | undefined;
  creatorName: string | undefined;
  urlArchive: string | undefined;
  urlImage: string | undefined;
  categories: Array<Category> | undefined;
  duration: string | undefined;
  type: string | undefined;

  constructor(id: number| undefined, name: string | undefined, authorName: string | undefined, urlAudio: string | undefined,
              urlImage: string | undefined, duration: string | undefined,
              categories: Array<Category>| undefined, type: string| undefined){
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

