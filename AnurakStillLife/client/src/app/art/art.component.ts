import { Component, OnInit } from '@angular/core';
import { Art, ArtList } from '../shared/modeles/arts';
import { ArtService } from './art.service';
import { response } from 'express';

@Component({
  selector: 'app-art',
  templateUrl: './art.component.html',
  styleUrl: './art.component.scss'
})
export class ArtComponent implements OnInit{

  artworks: Art[] = [];

  constructor(private artService: ArtService) {}

  ngOnInit(): void {

    this.artService.getArtWorks().subscribe({
      next: response => this.artworks = response.sort(),
      error: error => console.log(error)
    })
  }

}
