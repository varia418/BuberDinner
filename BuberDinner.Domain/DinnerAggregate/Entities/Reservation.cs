using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public sealed class Reservation : Entity<ReservationId>
{
    public enum Status { PendingGuestConfirmation, Reserved, Cancelled };

    public int GuestCount { get; }
    public string Description { get; }
    public Status ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArriveDateTime { get; } = null;
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        string description,
        Status reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arriveDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        Description = description;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArriveDateTime = arriveDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        int guestCount,
        string description,
        Status reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arriveDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            guestCount,
            description,
            reservationStatus,
            guestId,
            billId,
            arriveDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}