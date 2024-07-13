import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ArtDetailsComponent } from './art-details/art-details.component';

@NgModule({
  declarations: [
    ArtDetailsComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ]
})
export class ArtModule { }
