import { Component, inject } from '@angular/core';
import { ModalDismissReasons, NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddmovieComponent } from './components/addmovie/addmovie.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MovieLibrary';
  private modalService = inject(NgbModal);

  AddMovie():void
  {
    console.log("fsd");
		const modalRef = this.modalService.open(AddmovieComponent);

  }
}
