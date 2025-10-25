import { Component } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { SignUpModel } from '../model/SignUpModel';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { InventoryService } from '../../inventory-service';


@Component({
  selector: 'app-sign-up',
  imports: [FormsModule, ReactiveFormsModule, CommonModule, RouterLink],
  templateUrl: './sign-up.html',
  styleUrl: './sign-up.css'
})
export class SignUp {

  SignUpObject: SignUpModel = new SignUpModel();
  SignUpForms!: FormGroup;
  disabled = true;

  constructor(private service: InventoryService, private fb: FormBuilder) {
    this.SignUpForms = this.fb.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', Validators.required],
      Username: ['', Validators.required],
      password: ['', Validators.required],

    })


  }

  onsubmit() {
    if (this.SignUpForms.valid) {

      this.service.SignUpService(this.SignUpForms.value).subscribe({
        next: (res) => {
          console.log("User Registered Successfully", res);
          this.SignUpForms.reset();
        }, error: (err) => {
          console.log("Error while registering the user", err);
        }, complete: () => {
          console.log("Request Completed");
        }
      })
    }
    else {
      console.log("Form is invalid  OR Enter valid data");
    }
  }


}





