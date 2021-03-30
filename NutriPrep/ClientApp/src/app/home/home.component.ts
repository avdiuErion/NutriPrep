import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { GeneralService } from '../../_services/general.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  r: any;
  form: FormGroup;
  constructor(
    private generalService: GeneralService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      emriKlientit: [''],
      gjinia: [''],
      adresa: [''],
      mosha: [''],
      gjatesia: [''],
      pesha: [''],
      kohezgjatja: [''],
      aktiviteti: [''],
      qellimi: [''],
      nrShujtave: [''],
      sasia: [''],
      perkushtimi: [''],
      checkArray: this.formBuilder.array([])
    });
    this.generalService.getUshqimetPerEleminim().subscribe(res => {
      this.r = res;
      console.log(this.r);
    }, error => {
      console.log(error);
    });
  }

  onSubmit() {
    console.log(this.form.value);
  }

  onCheckboxChange(e) {
    const checkArray: FormArray = this.form.get('checkArray') as FormArray;

    if (e.target.checked) {
      checkArray.push(new FormControl(e.target.value));
    } else {
      let i: number = 0;
      checkArray.controls.forEach((item: FormControl) => {
        if (item.value == e.target.value) {
          checkArray.removeAt(i);
          return;
        }
        i++;
      });
    }
  }
}
