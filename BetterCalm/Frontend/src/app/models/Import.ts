import {Patient} from './Patient';
import {Psychology} from './Psychology';

export class Import {
  id!: number;
  name: string;
  path: string;


  constructor(id: number, name: string, path: string){
    this.id = id;
    this.name = name;
    this.path = path;
  }

}
