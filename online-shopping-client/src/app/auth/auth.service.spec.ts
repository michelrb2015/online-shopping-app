import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AuthService]
    });
    service = TestBed.inject(AuthService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should login successfully', () => {
    const username = 'admin';
    const password = 'admin';

    service.login(username, password).subscribe(response => {
      expect(response).toBeTruthy();
      expect(response).toEqual(1);
    });

    const req = httpMock.expectOne('http://localhost:5212/api/user/login');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ username, password });

    req.flush({ id: 1 });
  });

  it('should register successfully', () => {
    const username = 'testuser';
    const email = 'test@example.com';
    const password = 'testpassword';

    service.register(username, email, password).subscribe(response => {
      expect(response).toBeTruthy();
      expect(response).toBeTrue();
    });

    const req = httpMock.expectOne('http://localhost:5212/api/user/register');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ username, email, password });

    req.flush({}); // Mocking successful response
  });
});
