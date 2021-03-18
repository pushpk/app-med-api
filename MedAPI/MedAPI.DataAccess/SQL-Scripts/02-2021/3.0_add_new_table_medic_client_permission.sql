
Begin Transaction

Create table [registroclinico].patient_medic_permission(
patient_id bigint NOT NULL,
medic_id bigint NOT NULL,
is_medic_authorized bit NOT NULL,
is_future_request_blocked bit NOT NULL,
is_request_sent bit NOT NULL,

)
GO

ALTER TABLE [registroclinico].[patient_medic_permission]
    ADD CONSTRAINT pk_patient_medic PRIMARY KEY (patient_id,medic_id)
GO

ALTER TABLE [registroclinico].[patient_medic_permission] ADD  DEFAULT 0 FOR [is_medic_authorized]
GO

ALTER TABLE [registroclinico].[patient_medic_permission] ADD  DEFAULT 0 FOR [is_request_sent]
GO


ALTER TABLE [registroclinico].[patient_medic_permission] ADD  DEFAULT 0 FOR [is_future_request_blocked]
GO


ALTER TABLE [registroclinico].[patient_medic_permission]  WITH NOCHECK ADD  CONSTRAINT [patient_$FKgyco417bacd28ti07gdpxwvsr] 
FOREIGN KEY([patient_id])
REFERENCES [registroclinico].[patient]([id])
GO

ALTER TABLE [registroclinico].[patient_medic_permission]  WITH NOCHECK ADD  CONSTRAINT [medic_$FKgyco417bacd28ti07gdpxwvsr] 
FOREIGN KEY([medic_id])
REFERENCES [registroclinico].[medic] ([id])
GO


Commit Transaction