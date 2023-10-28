﻿
using MediatR;
using MyFamilyTree.ApplicationServices.API.Domain.Models;

namespace MyFamilyTree.ApplicationServices.API.Domain.Mediator.RequestResponses
{
    public class GetPeopleResponse : ResponseBase<List<Domain.Models.Person>>
    {

    }
}