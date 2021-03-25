import { Component, OnInit } from '@angular/core';
import { GeneralService } from '../../_services/general.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  r: any;

  constructor(
    private generalService: GeneralService,
  ) { }

  ngOnInit(): void {
    this.generalService.getMeals().subscribe(res => {
      this.r = res;
      console.log(this.r);
    }, error => {
      console.log(error);
    });
    }
}
