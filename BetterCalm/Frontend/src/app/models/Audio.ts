export class Audio {
  id: number;
  name: string;
  authorName: string;
  urlAudio: string;
  urlImage: string;

  constructor(id:number,name:string,authorName:string,urlAudio:string,urlImage:string){
    this.name = name;
    this.id=id;
    this.authorName=authorName;
    this.urlAudio=urlAudio;
    this.urlImage=urlImage
  }
}
