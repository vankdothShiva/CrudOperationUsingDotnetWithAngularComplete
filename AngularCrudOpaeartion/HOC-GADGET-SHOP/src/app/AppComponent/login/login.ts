import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { LoginModel } from '../model/LoginModel';
import { FormControl } from '@angular/forms';
import { InventoryService } from '../../inventory-service';
import { CommonModule } from '@angular/common';
import {  RouterLink, RouterModule } from '@angular/router';


@Component({
  selector: 'app-login',
  imports: [FormsModule,ReactiveFormsModule,CommonModule,RouterLink,RouterModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

 userLogin: LoginModel=new LoginModel();
 LoginForms!:FormGroup;

 constructor(private inventoryService:InventoryService,private fb:FormBuilder){ {

  this.LoginForms=this.fb.group({
    username:new FormControl('',Validators.required),
    password:new FormControl('',Validators.required),
  });
}
 }


 onsubmit(){
  if (this.LoginForms.valid) {
  this.inventoryService.LoginUser(this.LoginForms.value).subscribe(res=>{
   console.log(res);
  });
}
 else {
  console.log("Form is invalid  OR Enter valid data"); 
}
}
}
