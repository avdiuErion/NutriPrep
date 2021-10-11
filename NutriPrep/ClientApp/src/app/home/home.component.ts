import { AfterViewInit, Component, ElementRef, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import html2canvas from 'html2canvas';
import jspdf from 'jspdf';
import jsPDF from 'jspdf';
import { GeneralService } from '../../_services/general.service';
import { Breakfast } from '../Breakfast';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit{
  r: any;
  s: any;
  form: FormGroup;
  breakfasts: Breakfast[] = [];
  lunches: any;
  dinners: any;
  questionnaire: boolean = true;
    uToReturn: any;
  ushqimet: any;
  node: any;
  pp: any;
  constructor(
    private generalService: GeneralService,
    private formBuilder: FormBuilder,
    private elRef: ElementRef
  ) { }
    ngAfterViewInit(): void {
      this.pp = document.getElementsByClassName('paragraph');
      console.log(this.pp);
      this.node = document.createElement("P");
      
    }


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

    //this.giveValuesToForm();
    this.generalService.getUshqimetPerEleminim().subscribe(res => {
      this.r = res;
      console.log(this.r);
    }, error => {
      console.log(error);
    });
  }

  giveValuesToForm() {
    this.form.get('emriKlientit').setValue('Filan');
    this.form.get('adresa').setValue('jhwebhfwe');
    this.form.get('mosha').setValue(21);
    this.form.get('gjatesia').setValue(170);
    this.form.get('pesha').setValue(65);
    this.form.get('sasia').setValue(1);
  }

  onSubmit() {
    
    this.generalService.GetPlan(this.form.value).subscribe(res => {
      console.log(this.form.value);
      this.uToReturn = res;
      for (var i = 0; i < this.uToReturn.length; i++) {
        this.ushqimet = this.uToReturn[i];
        for (var j = 0; j < this.ushqimet.length - 1; j++) {
          var u1 = this.ushqimet[j] as Breakfast;
          var u2 = this.ushqimet[j + 1] as Breakfast;
          if (u1.shujtaId != u2.shujtaId) {
            document.appendChild < this.pp > (this.node);
          }
        }
      }
      
      console.log(this.uToReturn);
      console.log(this.breakfasts);
      this.questionnaire = false;
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
