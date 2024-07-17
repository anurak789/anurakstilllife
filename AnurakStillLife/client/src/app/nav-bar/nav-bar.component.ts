import { Component } from '@angular/core';
import { faPaintBrush } from '@fortawesome/free-solid-svg-icons';
import { faSmile } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.scss'
})
export class NavBarComponent {
  public isCollapsed : boolean = true;
email: any = 'pkanurak@gmail.com';
faPaintBrush = faPaintBrush;
faSmile = faSmile;
}
