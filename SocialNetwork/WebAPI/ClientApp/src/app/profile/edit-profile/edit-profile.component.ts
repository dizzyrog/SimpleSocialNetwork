import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  form:FormGroup;
  constructor() { }

  ngOnInit() {
    this.form = new FormGroup({
      firstName: new FormControl(),
      lastName: new FormControl(),
      age: new FormControl(),
      email:new FormControl(),
      userName:new FormControl(),
      password: new FormControl()
    }

    )
  }
  onSubmit(user) {
    // this.mediaItemService.add(mediaItem)
    //   .subscribe(() => {
    //     this.router.navigate(['/', mediaItem.medium]);
      //});
      console.log("form submitted");
  }
}
