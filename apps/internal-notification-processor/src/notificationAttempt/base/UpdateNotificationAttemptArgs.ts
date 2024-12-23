/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { NotificationAttemptWhereUniqueInput } from "./NotificationAttemptWhereUniqueInput";
import { ValidateNested } from "class-validator";
import { Type } from "class-transformer";
import { NotificationAttemptUpdateInput } from "./NotificationAttemptUpdateInput";

@ArgsType()
class UpdateNotificationAttemptArgs {
  @ApiProperty({
    required: true,
    type: () => NotificationAttemptWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptWhereUniqueInput)
  @Field(() => NotificationAttemptWhereUniqueInput, { nullable: false })
  where!: NotificationAttemptWhereUniqueInput;

  @ApiProperty({
    required: true,
    type: () => NotificationAttemptUpdateInput,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptUpdateInput)
  @Field(() => NotificationAttemptUpdateInput, { nullable: false })
  data!: NotificationAttemptUpdateInput;
}

export { UpdateNotificationAttemptArgs as UpdateNotificationAttemptArgs };
