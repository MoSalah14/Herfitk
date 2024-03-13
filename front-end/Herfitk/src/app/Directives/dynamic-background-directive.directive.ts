import { Directive,ElementRef, OnInit } from '@angular/core';

@Directive({
  selector: '[appDynamicBackgroundDirective]',
  standalone: true
})
export class DynamicBackgroundDirectiveDirective  implements OnInit {
  constructor(private el: ElementRef) {}

  ngOnInit() {
    // Subscribe to carousel slide event
    this.el.nativeElement.addEventListener('slid.bs.carousel', () => {
      const carousel = document.getElementById('carouselExampleIndicators');
      if (carousel) {
        const activeItem = carousel.querySelector('.carousel-item.active img');
        if (activeItem) {
          const imgUrl = activeItem.getAttribute('src');
          this.el.nativeElement.style.backgroundImage = `url('${imgUrl}')`;
        }
      }
    });
  }
}
