import { Component, OnInit } from '@angular/core';
import { IUser } from '../../interfaces/user.interface';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, Params } from '@angular/router';
import { RoleEnum } from '../../shared/config';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  userModel: IUser;
  userForm: FormGroup
  userId: number;

  get FirstName() {
    return this.userForm.get('FirstName');
  }

  get Email() {
    return this.userForm.get('Email');
  }

  roleOptions: any;
  roles = RoleEnum;

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private fb: FormBuilder
    ) {
      debugger;
      this.roleOptions = Object.keys(RoleEnum).filter(Number);
    }

  ngOnInit() {
    this.userId = 0;

    this.route.params.subscribe((params: Params) => {
      const userId = params['userId'];
      this.userId = ((typeof (userId) !== 'undefined' && userId.toLowerCase() !== 'create') ? userId : 0);
    });

    if(this.userId > 0) {
      this.getUser();
    }

    this.initForm();
  }

  initForm(): any {
    this.userForm = this.fb.group({
      Id : [],
      FirstName: ['', [Validators.required]],
      LastName: [],
      Email: ['', [Validators.required, Validators.email]],
      MobileNumber: [],
      BirthDate: [],
      Address: [],
      Roles: []
    });
  }

  getUser(): void {
    this.userService.getUser(this.userId).subscribe(
      (data) => {
        this.userModel = data;
      }
    )
  }
}