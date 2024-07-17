import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ArtComponent } from './art/art.component';
import { LoginComponent } from './account/login/login.component';
import { ArtDetailsComponent } from './art/art-details/art-details.component';
import { NetPostComponent } from './net-post/net-post.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'art', component: ArtComponent},
  {path: 'art/:id', component: ArtDetailsComponent},
  {path: 'netpost', component: NetPostComponent},  
  {path: 'login', component: LoginComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
