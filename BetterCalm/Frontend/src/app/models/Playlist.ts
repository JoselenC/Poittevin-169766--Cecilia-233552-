import {Category} from "./Category";
import {Audio} from "./Audio";

export class Playlist {
  id!:number;
  name: string;
  urlImage: string;
  categories:Array<Category>;
  audios: Array<Audio>;
  description:string;

  constructor(id:number,name:string,urlImage:string,description:string){
    this.id=id;
    this.categories=new Array<Category>();
    this.audios= new Array<Audio>();
    this.name = name;
    this.urlImage=urlImage;
    this.description=description
  }

}
