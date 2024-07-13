import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ArtList, Art } from '../shared/modeles/arts';


@Injectable({
  providedIn: 'root'
})
export class ArtService {

  baseUrl = 'https://localhost:7032/api/'

  constructor(private http: HttpClient) { }

  getArtWorks() {
    return this.http.get<Art[]>(this.baseUrl + 'arts');
  }

  getArt(id: number) {
    return this.http.get<Art>(this.baseUrl + 'arts/' + id);
  }
}
