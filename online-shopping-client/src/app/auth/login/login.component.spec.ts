import { ComponentFixture, TestBed } from '@angular/core/testing';
import { LoginComponent } from './login.component';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { Store } from '@ngrx/store';
import { AppState } from '../../store/reducers';
import { RouterTestingModule } from '@angular/router/testing';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { of } from 'rxjs';
import * as AuthActions from '../../store/actions/auth.action';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let store: jasmine.SpyObj<Store<AppState>>;

  beforeEach(async () => {
    store = jasmine.createSpyObj('Store', ['dispatch', 'select']);
    await TestBed.configureTestingModule({
      imports: [
        LoginComponent,
        MatCardModule,
        MatDividerModule,
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        MatButtonModule,
        RouterTestingModule,
        BrowserAnimationsModule
      ],
      providers: [
        { provide: Store, useValue: store }
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should dispatch AuthActions.login when onSubmit is called', () => {
    const username = 'testUser';
    const password = 'testPassword';
    component.loginForm.patchValue({ username, password });
    const loginAction = AuthActions.login({ username, password });
    component.onSubmit();
    expect(store.dispatch).toHaveBeenCalledWith(loginAction);
  });

  it('should navigate to products when isLoggedIn is true', () => {
    const navigateSpy = spyOn((component as any).router, 'navigate');
    store.select.and.returnValue(of(true));
    component.ngOnInit();
    expect(navigateSpy).toHaveBeenCalledWith(['products']);
  });

  it('should not navigate to products when isLoggedIn is false', () => {
    const navigateSpy = spyOn((component as any).router, 'navigate');
    store.select.and.returnValue(of(false));
    component.ngOnInit();
    expect(navigateSpy).not.toHaveBeenCalled();
  });

  afterEach(() => {
    component.ngOnDestroy();
  });
});
