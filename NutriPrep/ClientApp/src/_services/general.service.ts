import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class GeneralService {
  constructor(private http: HttpClient, @Inject('BASE_API_URL') private baseUrl: string) {}

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  getMeals(): Observable<any> {
    var result = this.http.get<any>(this.baseUrl + 'Meals/GetUShqimet/', this.httpOptions);
    console.log(result);
    return result;
  }
}
