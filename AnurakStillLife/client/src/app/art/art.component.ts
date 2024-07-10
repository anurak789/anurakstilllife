import { Component, OnInit } from '@angular/core';
import { findIndex } from 'rxjs';
import { Art, ArtList } from '../shared/modeles/arts';

@Component({
  selector: 'app-art',
  templateUrl: './art.component.html',
  styleUrl: './art.component.scss'
})
export class ArtComponent implements OnInit{

  artworks = ArtList;
  artWork1 = ArtList.findIndex(x => x.id === 0);
  artWork2 = ArtList.findIndex(x => x.id === 1);
  artWork3 = ArtList.findIndex(x => x.id === 2);

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
