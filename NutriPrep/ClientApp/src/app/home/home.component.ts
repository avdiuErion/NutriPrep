import { Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';
import jsPDF from 'jspdf';
import { GeneralService } from '../../_services/general.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  r: any;
  s: any;
  form: FormGroup;
  breakfasts: any;
  lunches: any;
  dinners: any;
  questionnaire: boolean = true;
  constructor(
    private generalService: GeneralService,
    private formBuilder: FormBuilder,
    private elRef: ElementRef
  ) { }

  ngOnInit(): void {
    console.log(this.questionnaire);

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
    this.generalService.GetPlan(this.form.value).subscribe(res => {
      console.log(this.form.value);
      this.breakfasts = res[0];
      this.lunches = res[1];
      this.dinners = res[2];
      this.questionnaire = false;
      console.log(this.breakfasts);
    }, error => {
      console.log(error);
    });
  }

  public downloadAsPDF() {
    //const doc = new jsPDF('p', 'pt', 'a4');

    //const specialElementHandlers = {
    //  '#editor': function (element, renderer) {
    //    return true;
    //  }
    //};

    //var el = this.elRef.nativeElement;
    //console.log(el);

    //console.log(this.pdfTable);
    //const pdfTable = this.elRef.nativeElement;

    //doc.html(pdfTable.innerHTML);

    var element = document.getElementById('pdfTable');
      html2canvas(element).then((canvas) => {
      var imgData = canvas.toDataURL('image/png');

      var doc = new jspdf();

      doc.addImage(imgData, 0, 0, 208, 500);
      //doc.save('tableToPdf.pdf');
        /*doc.output('dataurlnewwindow');*/
        var blob = doc.output("blob");
        window.open(URL.createObjectURL(blob));
    });
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

  Gjinia() { return this.form.get('gjinia').value; }
}
