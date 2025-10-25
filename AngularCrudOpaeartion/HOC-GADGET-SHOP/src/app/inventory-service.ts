import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from './AppComponent/model/LoginModel';
import { SignUpModel } from './AppComponent/model/SignUpModel';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  
  private apiUrl = "https://localhost:7001/";

  private LoginapiUrl="http://localhost:5131/";

httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'my-auth-token', // e.g., 'Bearer my-auth-token'
      'Content-Type': 'application/json' // ✅ 'Content-Type', not 'content-Type'
    })
  };

 

  constructor(private http: HttpClient) {}

  PostData(data: any): Observable<any> {
    return this.http.post(this.apiUrl + "api/Inventory", data, this.httpOptions);
  }

GetData(): Observable<any> {
  return this.http.get(this.apiUrl + "api/Inventory"); 
}

DeleteData(id:number): Observable<any> {
  return this.http.delete(this.apiUrl + "api/Inventory?ProductId="+id,this.httpOptions);
}

updateData(data: any): Observable<any> {

  const url = `${this.apiUrl}api/Inventory?ProductId=${data.productId}`;
  return this.http.put(url, data, this.httpOptions);
}


LoginUser(data: LoginModel): Observable<any> {
  return this.http.post(this.LoginapiUrl + "api/Login", data, this.httpOptions);
}

SignUpService(data: SignUpModel): Observable<any> {
  return this.http.post(this.LoginapiUrl + "api/SignUp", data, this.httpOptions);
}



}
