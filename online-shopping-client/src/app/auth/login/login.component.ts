import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { Store } from '@ngrx/store';
import { AppState } from '../../store/reducers';
import * as AuthActions from '../../store/actions/auth.action';
import { Observable, Subscription } from 'rxjs';
import { isLoggedIn } from '../../store/selectors';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit, OnDestroy {

  loginForm: FormGroup = this.fb.group({
    username: ["", [Validators.required]],
    password: ["", [Validators.required] ]
  });

  isLoggedIn$: Observable<boolean> | undefined;
  isLoggedInSubscription$: Subscription | undefined;

  constructor(private store: Store<AppState>, private fb: NonNullableFormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.isLoggedIn$ = this.store.select(isLoggedIn);
    if (this.isLoggedIn$) {
      this.isLoggedInSubscription$ = this.isLoggedIn$.subscribe(isLoggedIn => {
        if (isLoggedIn) {
          this.router.navigate(['products']);
        }
      });
    }
  }

  onSubmit(): void {
    const { username, password } = this.loginForm?.value
    this.store.dispatch(AuthActions.login({ username, password }));
  }

  ngOnDestroy(): void {
    this.isLoggedInSubscription$?.unsubscribe()
  }
}
