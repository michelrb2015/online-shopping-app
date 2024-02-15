import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Product } from '../shared/models/product.model';
import { ProductService } from './products.service';

describe('ProductService', () => {
  let service: ProductService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProductService]
    });
    service = TestBed.inject(ProductService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get products successfully', () => {
    const mockProducts: Product[] = [
      { id: 1, name: 'Product 1', description: '', price: 10 },
      { id: 2, name: 'Product 2', description: '', price: 20 },
    ];

    service.getProducts().subscribe((products: Product[]) => {
      expect(products).toBeTruthy();
      expect(products.length).toBe(2);
      expect(products).toEqual(mockProducts);
    });

    const req = httpMock.expectOne('http://localhost:5212/api/product/list');
    expect(req.request.method).toBe('GET');

    req.flush(mockProducts);
  });
});
