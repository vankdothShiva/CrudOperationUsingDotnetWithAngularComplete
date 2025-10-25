import { Routes } from '@angular/router';
import { Invertory } from './AppComponent/invertory/invertory';
import { Login } from './AppComponent/login/login';
import { signal } from '@angular/core';
import { SignUp } from './AppComponent/sign-up/sign-up';

export const routes: Routes = [
  { path: 'invertory', component: Invertory },
  { path: 'login', component: Login },
  
  { path: 'signUp', component: SignUp },
  
];