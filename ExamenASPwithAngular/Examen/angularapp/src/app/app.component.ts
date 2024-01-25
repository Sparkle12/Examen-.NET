import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public autori?: Autor[];
  public carte?: Carte;
  public autor?: Autor;
  public http!: HttpClient;

  constructor() {
    this.http.get<Autor[]>('https://localhost:7291/autor/all').subscribe(result => {
      this.autori = result;
    }, error => console.error(error));
  }

  getbyidf(data: any) {
    this.http.get<Carte>('https://localhost:7291/carte/'.concat(data.toString())).subscribe(result => {
      this.carte = result;
    });
  }

  getbyida(data: any) {
    this.http.get<Carte>('https://localhost:7291/carte/'.concat(data.toString())).subscribe(result => {
      this.autor = result;
    });
  }

  saveFormData(data: any) {
    return this.http.post('https://localhost:7291/carte/create', data);
  }

  dopost(data: any) {
    this.saveFormData(data).subscribe((result) => {
      console.warn(result)
    });
}

  title = 'angularapp';
}

interface Autor {
  Name: string;
}
interface Carte {
  Name : string;
  Autori: Autor[];
}
interface Editura {
  Name: string;
  Autori: Autor[];
}
