import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Invertory } from './invertory';

describe('Invertory', () => {
  let component: Invertory;
  let fixture: ComponentFixture<Invertory>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Invertory]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Invertory);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
