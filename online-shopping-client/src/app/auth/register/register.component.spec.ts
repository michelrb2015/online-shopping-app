import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RouterTestingModule } from '@angular/router/testing';
import { provideMockStore, MockStore } from '@ngrx/store/testing';
import { RegisterComponent } from './register.component';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;
  let store: MockStore;
  const initialState = { auth: { error: null } };

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        RegisterComponent,
        MatCardModule,
        MatDividerModule,
        MatFormFieldModule,
        MatInputModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        MatButtonModule,
        RouterTestingModule,
        BrowserAnimationsModule,
      ],
      providers: [provideMockStore({ initialState }), MatSnackBar],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    store = TestBed.inject(MockStore);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should dispatch register action on form submission', () => {
    const spyDispatch = spyOn(store, 'dispatch');
    const formData = {
      username: 'testuser',
      email: 'test@example.com',
      password: 'testpassword',
    };
    component.registerForm.setValue(formData);
    component.onSubmit();
    expect(spyDispatch).toHaveBeenCalledWith(
      jasmine.objectContaining({
        type: '[Auth] Register',
        username: formData.username,
        email: formData.email,
        password: formData.password,
      })
    );
  });

  it('should navigate to login page when registered', () => {
    const navigateSpy = spyOn((component as any).router, 'navigate');
    component.ngOnInit();
    store.setState({ auth: { error: null, isRegistered: true } });
    expect(navigateSpy).toHaveBeenCalledWith(['login']);
  });

  it('should show error snackbar when error occurs', () => {
    const snackBarOpenSpy = spyOn(
      (component as any)._snackBar,
      'openFromComponent'
    );
    component.ngOnInit();
    const error = 'An error occurred';
    store.setState({ auth: { error: error, isRegistered: false } });
    expect(snackBarOpenSpy).toHaveBeenCalledWith(
      jasmine.any(Function),
      jasmine.objectContaining({
        duration: 2000,
        data: error,
      })
    );
  });
});
