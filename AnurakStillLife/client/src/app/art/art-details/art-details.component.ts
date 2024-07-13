import { Component, OnInit } from '@angular/core';
import { ArtService } from '../art.service';
import { Art } from '../../shared/modeles/arts';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-art-details',
  templateUrl: './art-details.component.html',
  styleUrl: './art-details.component.scss'
})
export class ArtDetailsComponent implements OnInit{

  artwork?: Art;
  constructor(private artService: ArtService, private activatedRoute: ActivatedRoute) {}
  
  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) this.artService.getArt(+id).subscribe({
      next: response => this.artwork = response,
      error: error => console.log(error)
      })
    }
}
