import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from "ngx-spinner";
import { environment } from '../environments/environment';
import { identity } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{

  constructor(private spinner: NgxSpinnerService) {}

  ngOnInit(): void {
    /** spinner starts on init */
    environment.production ? identity : this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 1000);
  }
  title = 'anurakstilllife';
}
