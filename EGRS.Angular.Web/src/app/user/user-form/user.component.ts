import { Component, OnInit } from '@angular/core';
import { IUser, IUserRole } from '../../interfaces/user.interface';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { RoleEnum } from '../../shared/config';
import { User } from '../../models/user.model';
import { HelperService } from '../../services/helper.service';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  userModel: IUser = new User();
  userForm: FormGroup
  userId: number;
  dropdownList = [];
  selectedItems = [];
  dropdownSettings = {};

  get FirstName() {
    return this.userForm.get('FirstName');
  }

  get Email() {
    return this.userForm.get('Email');
  }

  get Roles() {
    return this.userForm.get('Roles');
  }

  roleOptions: IUserRole[];

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private helper: HelperService
    ) {
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

    this.roleOptions = [
      {
        Id: RoleEnum.Admin,
        Name: RoleEnum[RoleEnum.Admin]
      },
      {
        Id: RoleEnum.Patient,
        Name: RoleEnum[RoleEnum.Patient]
      },
      {
        Id: RoleEnum.Doctor,
        Name: RoleEnum[RoleEnum.Doctor]
      },
      {
        Id: RoleEnum.LabTechnician,
        Name: RoleEnum[RoleEnum.LabTechnician]
      },
      {
        Id: RoleEnum.Operator,
        Name: RoleEnum[RoleEnum.Operator]
      },
      {
        Id: RoleEnum.Accountant,
        Name: RoleEnum[RoleEnum.Accountant]
      },
      {
        Id: RoleEnum.Compounder,
        Name: RoleEnum[RoleEnum.Compounder]
      }
    ];

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'Id',
      textField: 'Name',
      allowSearchFilter: false,
      enableCheckAll: false
    };
  }

  initForm(): any {
    this.userForm = this.fb.group({
      FirstName: ['', [Validators.required]],
      LastName: [],
      Email: ['', [Validators.required, Validators.email]],
      MobileNumber: [],
      BirthDate: [],
      Address: [],
      Roles: [[], [Validators.required]]
    });
  }

  getUser(): void {
    this.userService.getUser(this.userId).subscribe(
      (data) => {
        this.userModel = data;
      }
    )
  }

  saveUser() {
    if(this.userForm.valid) {
      Object.assign(this.userModel, this.userForm.value);
      console.log(this.userModel);
      this.userService.addUser(this.userModel).subscribe(
        result => {
          this.router.navigate(['users/list']);
        },
        error => {
          this.helper.handleError(error);
        }
      )
    }
  }
}