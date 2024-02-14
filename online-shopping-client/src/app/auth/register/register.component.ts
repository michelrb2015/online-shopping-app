import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormGroup,
  FormsModule,
  NonNullableFormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { Store } from '@ngrx/store';
import { AppState } from '../../store/reducers';
import * as AuthActions from '../../store/actions/auth.action';
import { Observable, Subscription } from 'rxjs';
import { isRegistered } from '../../store/selectors';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SnackbarErrorComponent } from '../../shared/snackbar-error/snackbar-error.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent implements OnInit, OnDestroy {
  registerForm: FormGroup = this.fb.group({
    username: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
  });

  isRegistered$: Observable<boolean> | undefined;
  isRegisterSubscription$: Subscription | undefined;

  constructor(
    private store: Store<AppState>,
    private fb: NonNullableFormBuilder,
    private router: Router,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.isRegistered$ = this.store.select(isRegistered);
    if (this.isRegistered$) {
      this.isRegisterSubscription$ = this.isRegistered$.subscribe(
        (isRegistered) => {
          if (isRegistered) {
            this.router.navigate(['login']);
          }
        }
      );
    }
    this.store
      .select((state) => state.auth.error)
      .subscribe((err) => {
        if (err) {
          this._snackBar.openFromComponent(SnackbarErrorComponent, {
            duration: 2000,
            data: err,
          });
        }
      });
  }

  onSubmit(): void {
    const { username, password, email } = this.registerForm?.value;
    this.store.dispatch(AuthActions.register({ username, email, password }));
  }

  ngOnDestroy(): void {
    this.isRegisterSubscription$?.unsubscribe();
  }
}
