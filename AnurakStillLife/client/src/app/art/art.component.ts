import { Component, OnInit } from '@angular/core';
import { Art, ArtList } from '../shared/modeles/arts';

@Component({
  selector: 'app-art',
  templateUrl: './art.component.html',
  styleUrl: './art.component.scss'
})
export class ArtComponent implements OnInit{

  artworks: Art[] = ArtList;

  ngOnInit(): void {
    //throw new Error('Method not implemented.');
  }

}
