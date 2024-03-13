import { Component } from '@angular/core';

@Component({
  selector: 'app-category',
  standalone: true,
  imports: [],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  slide(direction: string) {
    const cards = Array.from(document.querySelectorAll('.card')) as HTMLElement[];
    const cardWidth = cards[0].clientWidth;

    if (direction === 'left') {
      cards.forEach((card: HTMLElement, index: number) => {
        const offset = index * cardWidth;
        card.style.transform = `translateX(-${offset}px)`;
      });
    } else if (direction === 'right') {
      cards.forEach((card: HTMLElement, index: number) => {
        const offset = index * cardWidth;
        card.style.transform = `translateX(${offset}px)`;
      });
    }
  }
}
