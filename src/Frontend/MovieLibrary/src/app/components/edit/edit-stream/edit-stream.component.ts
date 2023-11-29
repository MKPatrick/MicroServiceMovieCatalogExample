import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-edit-stream',
  templateUrl: './edit-stream.component.html',
  styleUrls: ['./edit-stream.component.css']
})
export class EditStreamComponent {
  @Input() MovieID!: number;
}
